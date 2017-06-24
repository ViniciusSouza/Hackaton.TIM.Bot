using System;
using System.Collections.Generic;

namespace Assets.BotDirectLine
{
    [System.Serializable]
    public class MessageActivity
    {   
        public DateTime Timestamp
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ChannelId
        {
            get;
            set;
        }

        public string FromId
        {
            get;
            set;
        }

        public string FromName
        {
            get;
            set;
        }

        public string ConversationId
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public string ReplyToId
        {
            get;
            set;
        }

        public List<Attachment> Attachments = new List<Attachment>();

        /// <summary>
        /// Constructor.
        /// </summary>
        public MessageActivity()
        {
            Attachments = new List<Attachment>();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="text"></param>
        /// <param name="channelId"></param>
        /// <param name="timestampString"></param>
        /// <param name="fromName"></param>
        /// <param name="conversationId"></param>
        /// <param name="replyToId"></param>
        public MessageActivity(string fromId, string text, string channelId,
            string timestampString = null, string fromName = null, string conversationId = null, string replyToId = null)
        {
            if (string.IsNullOrEmpty(timestampString))
            {
                Timestamp = DateTime.Now;
            }
            else
            {
                Timestamp = Convert.ToDateTime(timestampString);
            }

            ChannelId = channelId;
            FromId = fromId;
            FromName = fromName;
            ConversationId = conversationId;
            Text = text;
            ReplyToId = replyToId;
            Attachments = new List<Attachment>();
        }

        public static MessageActivity FromJson(SimpleJSON.JSONNode activityJsonRootNode)
        {
            MessageActivity messageActivity = new MessageActivity();
            messageActivity.Id = activityJsonRootNode[BotJsonProtocol.KeyId];
            messageActivity.Timestamp = Convert.ToDateTime(activityJsonRootNode[BotJsonProtocol.KeyTimestamp]);
            messageActivity.ChannelId = activityJsonRootNode[BotJsonProtocol.KeyChannelId];

            SimpleJSON.JSONNode fromJsonRootNode = activityJsonRootNode[BotJsonProtocol.KeyFrom];

            if (fromJsonRootNode != null)
            {
                messageActivity.FromId = fromJsonRootNode[BotJsonProtocol.KeyId];
                messageActivity.FromName = fromJsonRootNode[BotJsonProtocol.KeyName];
            }

            SimpleJSON.JSONNode conversationJsonRootNode = activityJsonRootNode[BotJsonProtocol.KeyConversation];

            if (conversationJsonRootNode != null)
            {
                messageActivity.ConversationId = fromJsonRootNode[BotJsonProtocol.KeyId];
            }

            UnityEngine.Debug.Log(activityJsonRootNode.Value);
            messageActivity.Text = activityJsonRootNode[BotJsonProtocol.KeyText];
            messageActivity.ReplyToId = activityJsonRootNode[BotJsonProtocol.KeyReplyToId];

            SimpleJSON.JSONNode jsonNode = activityJsonRootNode[BotJsonProtocol.KeyAttachments];
            if ((jsonNode) != null)
            {
                //eventArgs.Watermark = responseJsonRootNode[BotJsonProtocol.KeyWatermark];
                //Cada attachment individualmente
                SimpleJSON.JSONArray jsonArray = jsonNode.AsArray;
                
                foreach (SimpleJSON.JSONNode activityNode in jsonArray)
                {
                    UnityEngine.Debug.Log(activityNode.Value);
                    messageActivity.Attachments.Add(UnityEngine.JsonUtility.FromJson<Attachment>(activityNode.Value));
                    //MessageActivity messageActivity = MessageActivity.FromJson(activityNode);
                    //eventArgs.Messages.Add(messageActivity);
                }
            }

            return messageActivity;
        }

        public string ToJsonString()
        {
            string asJsonString =
                "{ \"" + BotJsonProtocol.KeyActivityType + "\": \"" + BotJsonProtocol.KeyMessage + "\", \""
                + BotJsonProtocol.KeyChannelId + "\": \"" + ChannelId + "\", \""
                + BotJsonProtocol.KeyFrom + "\": { \""
                    + BotJsonProtocol.KeyId + "\": \"" + FromId
                    + (string.IsNullOrEmpty(FromName) ? "" : ("\", \"" + BotJsonProtocol.KeyName + "\": \"" + FromName))
                + "\" }, \""
                + BotJsonProtocol.KeyText + "\": \"" + Text + "\" }";

            return asJsonString;
        }

        public override string ToString()
        {
            return ToJsonString();
        }
    }
}
