﻿using Sample.App.Domain.Models.V1;

namespace Sample.App.Domain.Contract.V1
{
    public interface IBaseEntity : IBasicEntity
    {
        public Guid StatusId { get; set; }
        public Status Status { get; set; }

        public Guid SubStatusId { get; set; }
        public SubStatus SubStatus { get; set; }

        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public Guid ModifiedById { get; set; }
        public User ModifiedBy { get; set; }
    }
}
