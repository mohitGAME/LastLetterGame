using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Google.Protobuf.WellKnownTypes;
using System.Collections.Generic;
using GrpcLastLetter.Data;
using StackExchange.Redis;

namespace GrpcLastLetter
{

    
    public class ChatService : WordChat.WordChatBase
    {
        private readonly SymSpell _symSpell;
        public ChatService(SymSpell symSpell)
        {
            _symSpell = symSpell;
        }
        public override Task<WordResponse> ReceiveWord(WordRequest request, ServerCallContext context)
        {
            bool isValid = false;

            var inputTerm = request.From;

            int maxEditDistanceLookup = 0; //max edit distance per lookup (maxEditDistanceLookup<=maxEditDistanceDictionary)
            var suggestionVerbosity = SymSpell.Verbosity.Top; //Top, Closest, All
            var suggestions = _symSpell.Lookup(inputTerm, suggestionVerbosity, maxEditDistanceLookup);

            //display suggestions, edit distance and term frequency
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine(suggestion.term + " " + suggestion.distance.ToString() + " " + suggestion.count.ToString("N0"));
                return Task.FromResult(new WordResponse
                {
                    IsValid = true
                });

            }
            return Task.FromResult(new WordResponse
            {
                IsValid = isValid
            });
        }



    }
}

