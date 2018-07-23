﻿using Newtonsoft.Json;
using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    class ApiRequest
    {
        private int _consecutiveFailures = 0;
        private int _consecutiveNullsReturned = 0;
        private const string EXCEEDED_LIMIT = "Response status code does not indicate success: 429 (Too Many Requests).";

        private RequestMaker requester = new RequestMaker();

        private void onRateLimitExceeded()
        {
            Console.WriteLine("Rate Limit Exceeded : WAITING 60 SECONDS");
            _consecutiveFailures++;
        }
        private void onRequestSuccess()
        {
            _consecutiveNullsReturned = 0;
            _consecutiveFailures = 0;
        }
        private void onOther()
        {
            _consecutiveNullsReturned++;
            if(_consecutiveNullsReturned > 10)
            {
                //something has gone wrong lets stop.
                throw new Exception();
            }
        }

        public Summoner getSummonerByName(string name)
        {
            Summoner result = null;
            string json = null;
            try
            {
                json = requester.Fetch(RequestStringHolder.SummonerRequest(name));
                result = RiotDtoFromJson.getSummoner(json);
            }
            catch
            {
                if(json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return getSummonerByName(name);
                }
                else
                {
                    onOther();
                    return null;
                }
            }
            
            return result;
        }
        
    }
}