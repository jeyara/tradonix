namespace Tradonix.Core.Entities
{
    public class Setting: IEntityBase
    {
        public long Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
