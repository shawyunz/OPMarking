using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OPMarking.Models;

namespace OPMarking.Services
{
    public class FormAIS : IDataStore<OPCriteria>
    {
        readonly List<OPCriteria> items;

        public FormAIS()
        {
            items = new List<OPCriteria>()
            {
                new OPCriteria { Line = "001001", Grade = 1, Title = "Focus", Description="Purpose of presentation is clear from the outset. Supporting ideas maintain clear focus on the topic." },
                new OPCriteria { Line = "001001", Grade = 2, Title = "Focus", Description="Topic of the presentation is clear.Content generally supports the purpose." },
                new OPCriteria { Line = "001001", Grade = 3, Title = "Focus", Description="Presentation lacks clear direction. Big ideas not specifically identified." },
                new OPCriteria { Line = "001001", Grade = 4, Title = "Focus", Description="No focus at all. Audience cannot determine purpose of presentation." },
                new OPCriteria { Line = "001002", Grade = 1, Title = "Organization", Description="Student presents information in logical, interesting sequence that audience follows." },
                new OPCriteria { Line = "001002", Grade = 2, Title = "Organization", Description="Student presents information in logical sequence that audience can follow." },
                new OPCriteria { Line = "001002", Grade = 3, Title = "Organization", Description="Audience has difficulty following because student jumps around." },
                new OPCriteria { Line = "001002", Grade = 4, Title = "Organization", Description="Audience cannot understand because there is no sequence of information." }
            };
        }

        public async Task<bool> AddItemAsync(OPCriteria item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(OPCriteria item)
        {
            var oldItem = items.Where((OPCriteria arg) => arg.Line == item.Line).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((OPCriteria arg) => arg.Line == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<OPCriteria> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Line == id));
        }

        public async Task<IEnumerable<OPCriteria>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}