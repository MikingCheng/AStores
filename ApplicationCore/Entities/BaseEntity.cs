using System;

namespace ApplicationCore.Entities
{
  // This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
  // Using non-generic integer types for simplicity and to ease caching logic
  public class BaseEntity
  {
    public int F_Id { get; set; }

    public byte[] RowVersion { get; set; }
    public DateTime F_LastModifiedDate { get; set; }
  }
}
