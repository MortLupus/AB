using Newtonsoft.Json;

namespace MVC4.Models
{
    public abstract class Entity
    {
        public string Id { get; set; }

        [JsonIgnore]
        public int IdAsANumber
        {
            get
            {
                if (string.IsNullOrEmpty(Id))
                {
                    return 0;
                }

                int index = Id.IndexOf('/');
                if (index < 0)
                {
                    return 0;
                }

                int id;
                return int.TryParse(Id.Substring(index + 1, Id.Length - index - 1), out id) ? id : 0;
            }
            set
            {
                if (value == 0)
                {
                    Id = null;
                    return;
                }

                Id = string.Format("{0}s/{1}", GetType().Name, value);
            }
        }

        public static bool IdComparer(Entity entity1, Entity entity2)
        {
            return entity1 != null && entity2 != null && entity1.Id == entity2.Id;
        }
    }


}