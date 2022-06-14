﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoldPrices.ClassLibrary
{
    public class GoldPrice
    {
        [JsonPropertyName("cena")]
        public decimal Price { get; set; }

        [JsonPropertyName("data")]
        public string Date { get; set; }
    }

    public interface IGoldPriceProvider
    {
        Task<List<GoldPrice>> GetGoldPrices();
    }

    public class MockedGoldPriceProvider : IGoldPriceProvider
    {
        public Task<List<GoldPrice>> GetGoldPrices()
        {
            List<GoldPrice> result = new List<GoldPrice>();
            result.Add(new GoldPrice() { Date = "Today", Price = 100.1M });
            result.Add(new GoldPrice() { Date = "Yesterday", Price = 1.1M });
            return new Task<List<GoldPrice>>(() => { return result; });
        }
    }

    public class PolishGoldPriceProvider : IGoldPriceProvider
    {
        public async Task<List<GoldPrice>> GetGoldPrices()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var streamTask = client.GetStreamAsync("http://api.nbp.pl/api/cenyzlota/last/30/");
            var goldPrices = await JsonSerializer.DeserializeAsync<List<GoldPrice>>(await streamTask);

            return goldPrices;
        }
    }
}
