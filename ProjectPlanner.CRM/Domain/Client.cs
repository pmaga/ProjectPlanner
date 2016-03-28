﻿using ProjectPlanner.Cqrs.Base.DDD.Domain;
using ProjectPlanner.CRM.Interfaces.Domain;

namespace ProjectPlanner.CRM.Domain
{
    public class Client : AggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        public string Phone { get; private set; }
        public string EmailAddress { get; private set; }

        public ClientStatus Status { get; set; }

        public Client(string code, string name, string phone, string emailAddress = null)
        {
            Code = code;
            Name = name;
            Phone = phone;
            EmailAddress = emailAddress;

            Status = ClientStatus.InActive;
        }
    }
}