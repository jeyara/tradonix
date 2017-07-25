namespace Tradonix.Core.Entities
{
    public class Setting: IEntityBase
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
