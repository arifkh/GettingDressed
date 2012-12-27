
namespace Commands.Netflix

open System
open System.Net
open System.Xml.Linq
open GettingReady.Model


type ReturnMovie() = 

 member private this.GetMoviesWithTermPirates = 
  let searchTerm = "pirates"
  let requestUri = new Uri(String.Format("http://api-public.netflix.com/catalog/titles/autocomplete?oauth_consumer_key={0}&term={1}"
   , Globals.consumerKey, searchTerm))
  let request = WebRequest.Create(requestUri) :?> HttpWebRequest
  request.Method <- "GET"
  let response = request.GetResponse() :?> HttpWebResponse
  let moviesElement = XElement.Load(response.GetResponseStream())  
  response.Close()
  
  let inline implicit arg =
   ( ^a : (static member op_Implicit : ^b -> ^a) arg)
  let (!!) : string -> XName = implicit
  let autoComplete = !!"autocomplete_item"
  let title = !!"title"
  let short = !!"short"
  let titleNames = 
   moviesElement.Elements(autoComplete)
   |> Seq.map (fun x-> x.Element(title).Attribute(short).Value)

  let listMovieTitles = List.ofSeq titleNames
  listMovieTitles

 member private this.GetRandomMovie =  
  let movieList = this.GetMoviesWithTermPirates
  let rand = new Random()
  let next = rand.Next(0, movieList.Length - 1)
  List.nth movieList next

 interface ICommand with
  member x.Print mode = 
   String.Format("Returning movie {0}", x.GetRandomMovie)
  member x.CanPrint mode = true

