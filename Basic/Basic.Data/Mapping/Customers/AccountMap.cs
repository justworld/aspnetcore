﻿using Basic.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Basic.Data.Mapping
{
    public class AccountMap : MapBase<Account>
    {
        public override Action<EntityTypeBuilder<Account>> BuilderAction { get; }

        public AccountMap()
        {
            BuilderAction = entry =>
            {
                entry.HasKey(t => t.Id);

                // Properties
                // Table & Column Mappings
                entry.ToTable("Account");
            };
        }
    }
}
