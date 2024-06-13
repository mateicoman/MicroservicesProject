using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Domain.Specifications;

public class GetExistingProductByIdAndName : Specification<Product>
{
    public GetExistingProductByIdAndName(Guid? productId, string productName):
        base(x => (productId.Equals(null) || !x.Id.Equals(productId.Value)) && x.Name == productName)
    {        
    }
}