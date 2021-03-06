using Microsoft.AspNetCore.Mvc;


namespace StellarPayRoll.Core.Models.Datatable
{
    [ModelBinder(BinderType = typeof(DatatableRequestModelBinder))]
    public class DatatableRequest
    {
        public DatatablePagination Pagination { get; set; }
        public DatatableQuery Query { get; set; }
        public DatatableSort Sort { get; set; }
    }
}