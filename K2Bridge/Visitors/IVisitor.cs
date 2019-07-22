﻿namespace K2Bridge
{
    using K2Bridge.Models.Aggregations;

    internal interface IVisitor
    {
        void Visit(MatchPhraseQuery matchPhraseQuery);

        void Visit(Query query);

        void Visit(ElasticSearchDSL elasticSearchDSL);

        void Visit(RangeQuery rangeQuery);

        void Visit(BoolClause boolClause);

        void Visit(SortClause sortClause);

        void Visit(DateHistogram dateHistogram);

        void Visit(Aggregation aggregation);
    }
}
