using SportsStore.Domain.Entities;
using System.Linq;


namespace SportsStore.Domain.Abstract
{
    /// <summary>
    /// 创建一个抽象的存储库
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// 可以获取Product对象而不必知道他们来自哪里、如何递交他们，这是存储库的本质。
        /// </summary>
        IQueryable<Product> Products { get; }
    }
}
