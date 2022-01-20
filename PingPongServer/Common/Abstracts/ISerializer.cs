namespace Common.Abstracts
{
    public interface ISerializer<TObject, TData>
    {
        TData Serialize(TObject data);

        TObject Deserialize(TData data);
    }
}
