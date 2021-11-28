using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assingment1.Data;
using Assingment1.Models;
using Assingment1.Pages.Fam;

namespace Assingment1.Persistence
{
    public class FamilyDataRest : IFamiliesData
    {
        private HttpClient _client;
        private string _url;

        public FamilyDataRest()
        {
            _client = new HttpClient();
            _url = "https://localhost:5001/";
        }

        private async Task<string> Get(string args)
        {
            Console.WriteLine(_url + args);
            HttpResponseMessage responseMessage = await _client.GetAsync(_url + args);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error:{responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            return await responseMessage.Content.ReadAsStringAsync();
        }

        private async Task<string> Post(string args, string body)
        {
            Console.WriteLine(_url + args);
            Console.WriteLine(body);
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _client.PostAsync(_url + args, content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error:{responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            return await responseMessage.Content.ReadAsStringAsync();
        }

        private async Task Delete(string args)
        {
            HttpResponseMessage responseMessage = await _client.DeleteAsync(_url + args);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error:{responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task<IList<Family>> GetFamilies()
        {
            string responese = await Get("Family");
            List<Family> family = JsonSerializer.Deserialize<List<Family>>(responese, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return family;
        }

        public async Task<Family> GetFamily(string id)
        {
            string responese = await Get($"Family?familyId={id}");
            List<Family> family = JsonSerializer.Deserialize<List<Family>>(responese, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return family[0];
        }

        public async Task<Family> AddFamily(Family family)
        {
            string fam = JsonSerializer.Serialize(family);
            string response = await Post("Family", fam);
            Family fami = JsonSerializer.Deserialize<Family>(response, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return fami;
        }

        public async void RemoveFamily(int? id)
        {
            await Delete("Family/" + id);
        }

        public async Task<Adult> AddAdult(Adult adult, int familyId)
        {
            string adultS = JsonSerializer.Serialize(adult);
            string response = await Post($"Family/{familyId}/Adult", adultS);
            Adult adultResponse = JsonSerializer.Deserialize<Adult>(response, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return adultResponse;
        }

        public async Task<Child> AddChild(Child child, int familyId)
        {
            string childSerilazed = JsonSerializer.Serialize(child);
            string response = await Post($"Family/{familyId}/Child", childSerilazed);
            Child childResponse = JsonSerializer.Deserialize<Child>(response, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return childResponse;
        }

        public async Task<Pet> AddPet(Pet pet, int familyId)
        {
            string petSerialize = JsonSerializer.Serialize(pet);

            string response = await Post($"Family/{familyId}/Pet", petSerialize);
            Pet petResponse = JsonSerializer.Deserialize<Pet>(response, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return petResponse;
        }

        public async void RemoveAdult(int familyId, string? adultName)
        {
            await Delete($"Family/{familyId}/Adult/{adultName}");
        }

        public async void RemoveChild(int familyId, string childName)
        {
            try
            {
                await Delete($"Family/{familyId}/Child/{childName}");
                Console.WriteLine("here1");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async void RemovePet(int familyId, string petName)
        {
            await Delete($"Family/{familyId}/Pet/{petName}");
        }


        public async Task<IList<Child>> GetAllChildren()
        {
            IList<Child> children = new List<Child>();
            foreach (var family in await GetFamilies())
            {
                if (family.Pets != null)
                {
                    foreach (var child in family.Children)
                    {
                        children.Add(child);
                    }
                }
            }

            return children;
        }

        public async Task<IList<Adult>> GetAllAdults()
        {
            IList<Adult> adults = new List<Adult>();
            foreach (var family in await GetFamilies())
            {
                if (family.Adults != null)
                {
                    foreach (var adult in family.Adults)
                    {
                        adults.Add(adult);
                    }
                }
            }

            return adults;
        }


        public async Task<IList<Pet>> GetAllPets()
        {
            IList<Pet> pets = new List<Pet>();
            foreach (var family in await GetFamilies())
            {
                if (family.Pets != null)
                {
                    foreach (var pet in family.Pets)
                    {
                        pets.Add(pet);
                    }
                }
            }

            return pets;
        }
    }
}