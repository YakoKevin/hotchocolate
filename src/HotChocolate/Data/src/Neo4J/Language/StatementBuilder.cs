using System.Collections.Generic;
using System.Linq;

namespace HotChocolate.Data.Neo4J.Language
{
    public class StatementBuilder
    {
        private bool IsWrite = false;
        private Match? _match;
        private Where? _where;
        private Return? _return;
        //private readonly string Order;
        //private readonly string Limit
        //private readonly string

        public StatementBuilder OptionalMatch(params PatternElement[] elements) =>
            Match(true, elements);
        public StatementBuilder Match(params PatternElement[] elements) =>
            Match(false, elements);

        private StatementBuilder Match(bool optional, params PatternElement[] elements)
        {
            _match = new Match(optional, new Pattern(elements), null);
            return this;
        }

        // public StatementBuilder Return(params PatternElement[] elements) =>
        //     Return(false, elements);
        // public StatementBuilder ReturnDistinct(params PatternElement[] elements) =>
        //     Return(true, elements);
        //
        // private StatementBuilder Return(bool distinct, params INamed[] elements)
        // {
        //     _return = new Return(distinct, elements);
        //     return this;
        // }

        public string Build()
        {
            using var visitor = new CypherVisitor();
            if (!IsWrite)
            {
                _match?.Visit(visitor);
                _where?.Visit(visitor);
                _return?.Visit(visitor);
            }
            else
            {
                // TODO: Write Implementation
            }
            return visitor.Print();
        }
    }

    public class MatchBuilder
    {
        private readonly List<PatternElement> _patternList = new();

    }

    public class ConditionBuilder
    {
        private readonly List<PatternElement> _patternList = new();

    }

    public class OrderBuilder
    {
        private readonly List<PatternElement> _patternList = new();

    }
}
