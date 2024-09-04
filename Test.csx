using HttpClient;

// Directory.CreateDirectory("new_directory");
// try
// {
//     Directory.CreateDirectory("new_directory");
// }
// catch (Exception)
// {
//     Console.WriteLine("adasd");
// }

int[] l = [1, 2, 3, 4, 5];
var l2 = (1, "asdasd", true, false);
foreach (var i in IterateTuple(l2))
{
    Console.WriteLine(i);
}

static IEnumerable<object> IterateTuple<T1, T2, T3>((T1, T2, T3) tuple)
{
    yield return tuple.Item1;
    yield return tuple.Item2;
    yield return tuple.Item3;
}

string url = "https://jsonplaceholder.typicode.com/posts"

using HttpClient client = new() {

HttpResponseMessage message = await client.GetAsync(url);

string responseBody = await message.Conent.ReadAsStringAsync();
}
