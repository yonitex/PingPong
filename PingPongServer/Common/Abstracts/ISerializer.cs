namespace Common.Abstracts
{
    public interface ISerializer<TObject>
    {
        byte[] Serialize(TObject data);

        TObject Deserialize(byte[] data);
    }
}
