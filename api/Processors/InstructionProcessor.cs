﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace api.Processors {
    [ApiController]
    [Route("[controller]")]
    public class InstructionProcessor {

        static async public Task<List<Instruction>> GetInstructionsByRecipe(int recipeId) {
            List<Instruction> instructions = new List<Instruction>();
            try {
                var query = $"SELECT step,description FROM recipe JOIN instruction WHERE recipe.id = instruction.recipe and id = {recipeId};";
                var reader = await DbConnection.ExecuteQuery(query);

                if(reader.HasRows) {
                    while(await reader.ReadAsync()) {
                        var step = (int)reader.GetValue(0);
                        var description = (string)reader.GetValue(1);
                        instructions.Add(new Instruction(step, description));
                    }
                }
            }
            catch { }
            return instructions;
        }
        /*
        static async public Task<List<Instruction>> AddInstructions(List<Instruction> instructions) {

        }
        static async public Task<List<Instruction>> UpdateInstructions(List<Instruction> instructions) {

        }

        static async public Task<bool> DeleteInstructionsByRecipe(int recipeId) {

        }
        */
    }
}
