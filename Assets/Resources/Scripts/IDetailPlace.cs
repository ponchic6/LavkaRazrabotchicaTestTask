public interface IDetailPlace
{
    public void Show();
    public void Hide();
    public IDetail GetNecesseryDetail();
    public void SetNecesseryDetailMaterial();
    public bool HasParent();
    public bool HasDetail();
}