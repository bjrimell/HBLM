namespace Hablame.Common.Mapping
{
    using System.Diagnostics;
    using AutoMapper;

    public static class EntityMapper
    {
        static EntityMapper()
        {
            // don't want to throw exceptions here so call the try version
            Configuration.TryConfigure();
        }

        /// <summary>
        /// Generic method to do a quick mapping
        /// </summary>
        /// <typeparam name="TSource">The type of the source object/collection</typeparam>
        /// <typeparam name="TDestination">The type of the destination object/collection</typeparam>
        /// <param name="source">The source object/collection</param>
        /// <returns>An object/collection in the type of the destination</returns>
        public static TDestination MapXtoY<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// Method to attempt to map an object to another type
        /// </summary>
        /// <typeparam name="TDestination">The type to convert to</typeparam>
        /// <param name="source">The source object</param>
        /// <returns>An instance of <typeparam name="TDestination">TDestination</typeparam>  with properties from <paramref name="source"/> source</returns>
        public static TDestination MapTo<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// Method used to map from source object to existing destination object
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static TDestination MapOnTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }

    }
}