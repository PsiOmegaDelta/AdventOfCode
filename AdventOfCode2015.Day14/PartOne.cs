namespace AdventOfCode2015.Day14
{
    public static class PartOne
    {
        // Playing around with separation of data and logic
        public static int CalculatePartOne(this IEnumerable<Reindeer> reindeers, int raceTime)
        {
            var enumeratedReindeers = reindeers.ToList();
            var reindeerMetadata = enumeratedReindeers.ToDictionary(x => x, x => (Distance: 0, Flying: true, Timer: x.FlightTime));
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
            }

            return reindeerMetadata.Max(x => x.Value.Distance);
        }
    }
}
