﻿namespace NServiceBus.Gateway.Routing.Sites
{
    using System.Collections.Generic;
    using System.Configuration;
    using Channels;
    using Channels.Http;
    using Unicast.Transport;

    public class LegacySiteRouter:IRouteMessagesToSites
    {
        readonly string remoteUrl;

        public LegacySiteRouter()
        {
            remoteUrl = ConfigurationManager.AppSettings["RemoteUrl"];
        }

        public IEnumerable<Site> GetDestinationSitesFor(TransportMessage messageToDispatch)
        {
            var address = GetRemoteAddress(messageToDispatch);

            return new []{new Site
            {
                Channel = new Channel{Address = address,Type = "Http"},
                Key = address
            }};
        }

        string GetRemoteAddress(TransportMessage msg)
        {
            if (msg.Headers.ContainsKey(Headers.HttpTo))
                return msg.Headers[Headers.HttpTo];

            return remoteUrl;
        }

    }
}