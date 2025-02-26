﻿namespace NTierArchitecture.Entities.Abstractions;
public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set;}
    public string CreatedBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set;}

}
