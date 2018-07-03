using DEMO.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DEMO.Data
{
    // partial    => clase que puede definirse su contenido en distintos archivos

    // <T>        => tipo genérico, es una clase que acepta un tipo de dato y son referenciados
    //               por placeholders entre los signos < >, para una maxima reutilización de código

    // where T    => es una manera restringir los tipos de datos que aceptará la clase genérica

    //IQueryable  => es la producciòn de una consulta SQL
    public partial interface IRepository<T>
        where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }

        void UpdateBatch(List<T> entities);
        void InsertBatch(T entity);

        void DeleteBatch(T entity);
    }
}
