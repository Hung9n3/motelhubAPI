﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotelHubApi.Infrastructure;

namespace MotelHubApi.WebApi;

public class ContractController : ApiControllerBase<Contract, IContractLogic>
{
    public ContractController(IContractLogic logic) : base(logic)
    {
    }
}
