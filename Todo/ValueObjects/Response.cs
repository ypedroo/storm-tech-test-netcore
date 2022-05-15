namespace Todo.ValueObjects
{
    public record Response
    {
        public Entry[] Entry { get; set; }
    }
}