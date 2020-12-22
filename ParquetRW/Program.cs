using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Parquet;
using Parquet.Data;
using Parquet.Data.Rows;
using ParquetRW.Models;

namespace ParquetRW {
    class Program {
        static void Main (string[] args) {

            List<Automobile> list;
            //populate the list from csv, database, xml, etc
            using (var reader = new StreamReader ("/Users/David/repo/ParquetCS/ParquetRW/Data/auto.csv"))
            using (var csv = new CsvReader (reader, CultureInfo.InvariantCulture)) {
                var records = csv.GetRecords<Automobile> ();
                list = records.ToList<Automobile> ();
            }
            var cmake = new DataField<string> ("make");
            var cmodel = new DataField<string> ("model");
            var dprice = new DataField<decimal> ("price");

            var schema = new Schema (
                cmake,
                cmodel,
                dprice);

            var table = new Table (schema);

            foreach (var item in list) {
                table.Add (item.Make, item.Model, item.Price);
            }
            using (Stream fileStream = File.OpenWrite ("ParquetRW/Data/auto.parquet")) {
                using (var writer = new ParquetWriter (table.Schema, fileStream)) {
                    writer.Write (table);
                }
            }
            Table table2;
            using (Stream fileStream = File.OpenRead ("ParquetRW/Data/auto.parquet")) {
                using (var reader = new ParquetReader (fileStream)) {
                    table2 = reader.ReadAsTable ();
                    Console.WriteLine (table2.ToString ());
                }
            }
        }
    }
}