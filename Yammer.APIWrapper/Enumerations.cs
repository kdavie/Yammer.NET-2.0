using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper
{
    public enum WebMethod
    {
        GET,
        POST,
        DELETE,
        PUT
    }

    public enum ObjectType
    {
        NONE,
        MESSAGE,
        USER,
        TAG,
        THREAD,
        GROUP,
        GUIDE,
        BOT
    }

    public enum PageFlag
    {
        OLDER_THAN,
        NEWER_THAN
    }

    public enum AttachmentType
    {
        NONE,
        IMAGE,
        FILE
    }

    public enum SortBy
    {
        NONE,
        MESSAGES,
        MEMBERS,
        PRIVACY,
        CREATED_AT,
        CREATOR,
        FOLLOWERS
    }
    public enum PrivacyFlag
    {
        Public,
        Private
    }

    public enum RelationshipType
    {
        SUBORDINATE,
        SUPERIOR,
        COLLEAGUE
    }
}
