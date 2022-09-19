namespace CustomerManagementEF.Interfaces;

public interface IService<TEntity>
{
    TEntity? Get(int entityId);
    TEntity? Create(TEntity entity);
    bool Update(TEntity entity);
    bool Delete(int entityId);
    List<TEntity> GetAll();
}
