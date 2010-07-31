using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yammer.APIWrapper.OAuth;
using System.Net;

namespace Yammer.APIWrapper
{
    public class Session
    {
        public static bool Authorized
        {
            get
            {
                return Session.Auth != null;
            }
        }

        private static Auth auth;

        public static Auth Auth
        {
            get
            {
                if (auth == null)
                    CheckAuth();

                return auth;
            }
            set
            {
                auth = value;
                if (auth != null)
                    auth.AuthorizationComplete += new EventHandler(Auth_AuthorizationComplete);
            }
        }

        public static Settings Settings { get; set; }

        public static WebProxy WebProxy { get; set; }

        private static void CheckAuth()
        {
            string ck = Configuration.ConsumerKey;
            string cs = Configuration.ConsumerSecret;
            Session.Settings = Settings.CheckConfiguration();
            if (Session.Settings != null)
            {
                Session.Auth = new Auth();
                Session.Auth.Key = new OAuthKey(ck, cs, Session.Settings.OAuth.TokenKey, Session.Settings.OAuth.TokenSecret);
            }

        }

        static void Auth_AuthorizationComplete(object sender, EventArgs e)
        {
            OnAuthorizationComplete();
        }
        public static event EventHandler AuthorizationComplete;
        public static void OnAuthorizationComplete()
        {
            string log = Session.Auth.Success ? "Authorization completed - success" : "Authorization completed - failure";
          
            if (Session.Auth.Success)
                Session.Settings = Settings.CheckConfiguration();

            if (Session.AuthorizationComplete != null)
                Session.AuthorizationComplete(null, new EventArgs());
        }

        

        public static void End()
        {
            Session.Auth = null;
            if (Session.Ending != null)
                Session.Ending(null, EventArgs.Empty);
        }

        public static EventHandler Ending;


        public static void Start()
        {
            //threading.Thread thread = new threading.Thread(new ThreadStart(GetRequestToken));
            //thread.Start();
            GetRequestToken();
        }

        private static void GetRequestToken()
        {

            string ck = Configuration.ConsumerKey;
            string cs = Configuration.ConsumerSecret;
            Session.Auth = Yammer.APIWrapper.Auth.GetRequestToken(Session.WebProxy, ck, cs);
            //TODO: Allow callback URL
            if (Session.Auth != null)
            {
                Session.Auth.Proxy = Session.WebProxy;
                Session.Auth.Authorize(null);
            }

            Session.OnReceiveRequestToken();
        }

        public static event EventHandler ReceiveRequestToken;

        static void OnReceiveRequestToken()
        {
            if (Session.ReceiveRequestToken != null)
                Session.ReceiveRequestToken(null, new EventArgs());
        }
    }
}
