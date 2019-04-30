﻿using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.QnA;

namespace EnterpriseBot2.Middleware.Telemetry
{
    public interface ITelemetryQnAMaker
    {
        bool LogPersonalInformation { get; }

        Task<QueryResult[]> GetAnswersAsync(ITurnContext context, QnAMakerOptions options = null);
    }
}