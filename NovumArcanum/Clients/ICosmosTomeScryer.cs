﻿///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Microsoft.Azure.Cosmos;

namespace NovumArcanum.Clients
{
    public interface ICosmosTomeScryer
    {
        CosmosClient Scryer();
    }
}