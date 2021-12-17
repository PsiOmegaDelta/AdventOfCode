namespace AdventOfCode2015.Day14
{
    public static class PartTwo
    {
        public static int CalculatePartTwo(this IEnumerable<Reindeer> reindeers, int raceTime)
        {
            var enumeratedReindeers = reindeers.ToList();
            var reindeerMetadata = enumeratedReindeers.ToDictionary(x => x, x => (Distance: 0, Flying: true, Timer: x.FlightTime));
            var scores = enumeratedReindeers.ToDictionary(x => x, _ => 0);
            for (int i = 0; i < raceTime; i++)
            {
                foreach (var reindeer in enumeratedReindeers)
                {
                    var metadata = reindeerMetadata[reindeer];
                    if (metadata.Flying)
                    {
                        metadata.Distance += reindeer.FlightSpeed;
                    }

                    metadata.Timer--;
                    if (metadata.Timer == 0)
                    {
                        metadata.Flying = !metadata.Flying;
                        metadata.Timer = metadata.Flying ? reindeer.FlightTime : reindeer.RestTime;
                    }

                    reindeerMetadata[reindeer] = metadata;
                }

                var reindeerInLead = reindeerMetadata.MaxBy(x => x.Value.Distance).Key;
                scores[reindeerInLead]++;
            }

            return scores.Values.Max();
        }
    }
}
