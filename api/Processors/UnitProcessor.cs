﻿using api.Database;
using api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Processors {
    public class UnitProcessor {
        static public async Task<Unit> GetUnitByName(string unitName) {
            try {
                var query = $@"SELECT id, name, shortname
                            FROM unit 
                            WHERE name = '{unitName}'";
                var reader = await DbConnection.ExecuteQuery(query);
                if(reader.HasRows) {
                    await reader.ReadAsync();
                    var id = (int?)reader.GetValue(0);
                    var name = (string)reader.GetValue(1);
                    var shortname = (string)reader.GetValue(2);
                    return new Unit(id, name, shortname);
                }
                else {
                    return new Unit();
                }
            }
            catch { return new Unit(); }
        }
    }
}
