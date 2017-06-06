﻿using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using UltimateWorkflowToolkit.CoreOperations.Base;

namespace UltimateWorkflowToolkit.CoreOperations
{
    public class QuoteGetProductsFromOpportunity: CopyDetailsWorkflowsBase
    {
        #region Input/Output Parameters

        [Input("Quote")]
        [ReferenceTarget("quote")]
        [RequiredArgument]
        public InArgument<EntityReference> Quote { get; set; }

        [Input("Opportunity")]
        [ReferenceTarget("opportunity")]
        [RequiredArgument]
        public InArgument<EntityReference> Opportunity { get; set; }

        #endregion Input/Output Parameters

        #region Overriddes

        protected override EntityReference GetSourceEntityParent(CodeActivityContext executionContext)
        {
            return Opportunity.Get(executionContext);
        }

        protected override EntityReference GetTargetEntityParent(CodeActivityContext executionContext)
        {
            return Quote.Get(executionContext);
        }

        protected override string SourceEntity => "opportunityproduct";
        protected override string SourceEntityLookupFieldName => "opportunityid";
        protected override string TargetEntity => "quotedetail";
        protected override string TargetEntityLookupFieldName => "quoteid";

        #endregion Overriddes

    }
}
