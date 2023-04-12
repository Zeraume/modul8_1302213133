using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302213133
{
    public class BankTransferConfig
    {
        public Config config;

        private const string filepath = @"bank_transfer_json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteConfigFile();
            }
        }

        public Config ReadConfigFile()
        {
            string hasil = File.ReadAllText(filepath);
            config = JsonSerializer.Deserialize<Config>(hasil);
            return config;
        }

        public void SetDefault()
        {
            config = new Config("en",
                new Transfer(25000000, 6500, 15000),
                new List<string>{"RTO (real-time)", "SKN", "RTGS", "BI FAST"},
                new Confirmation("yes", "ya")
                );
        }

        public void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string teks = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filepath, teks);
        }

        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }

            public Transfer() { }

            public Transfer(int threshold, int low_fee, int high_fee)
            {
                this.threshold = threshold;
                this.low_fee = low_fee;
                this.high_fee = high_fee;
            }
        }

        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }

            public Confirmation() { }

            public Confirmation(string en, string id)
            {
                this.en = en;
                this.id = id;
            }
        }

        public class Config
        {
            public string lang { get; set; }
            public Transfer transfer { get; set; }
            public List<string> methods { get; set; }
            public Confirmation confirmation { get; set; }
            public Config() { }

            public Config(string lang, Transfer transfer, List<string> methods, Confirmation confirmation)
            {
                this.lang = lang;
                this.transfer = transfer;
                this.methods = methods;
                this.confirmation = confirmation;
            }
        }
    }
}
