using Newtonsoft.Json;

namespace StarWarsProject.Models
{
    public class Weapon
    {
        public int WeaponId { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }

        [JsonIgnore]
        public ICollection<Character> Character { get; set; }
    }
}
