﻿using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Taitans.Abp.OcelotManagement
{
    public class ReRouteRateLimitRule : Entity
    {
        public virtual Guid GlobalConfigurationId { get; protected set; }
        public virtual string ReRouteName { get; protected set; }

        public virtual List<ReRouteRateLimitRuleClientWhitelist> ClientWhitelist { get; protected set; }

        public ReRouteRateLimitRule()
        {
            ClientWhitelist = new List<ReRouteRateLimitRuleClientWhitelist>();
        }

        public virtual void AddWhitelist(string whitelist)
        {
            ClientWhitelist.Add(new ReRouteRateLimitRuleClientWhitelist(whitelist));
        }

        public virtual void RemoveAllWhitelists()
        {
            ClientWhitelist.Clear();
        }

        public void RemoveWhitelists(string whitelist)
        {
            ClientWhitelist.RemoveAll(c => c.Whitelist == whitelist);
        }

        public void FindWhitelist(string whitelist)
        {
            ClientWhitelist.FirstOrDefault(c => c.Whitelist == whitelist);
        }

        public override object[] GetKeys()
        {
            return new object[] { GlobalConfigurationId, ReRouteName };
        }
    }
}