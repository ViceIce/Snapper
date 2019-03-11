using System;
using Snapper.Core;
using Snapper.Core.TestMethodResolver;
using Snapper.Json;

namespace Snapper
{
    internal static class SnapperFactory
    {
        public static Snapper GetJsonSnapper() => JsonSnapper.Value;

        private static readonly Lazy<Snapper> JsonSnapper =
            new Lazy<Snapper>(CreateJsonSnapper);

        private static Snapper CreateJsonSnapper()
        {
            var testMethodResolver = new TestMethodResolver();
            return new Snapper(new JsonSnapshotStore(), new SnapshotUpdateDecider(testMethodResolver),
                new JsonSnapshotComparer(), new SnapshotIdResolver(testMethodResolver), new JsonSnapshotSanitiser(),
                new SnapshotAsserter());
        }
    }
}
