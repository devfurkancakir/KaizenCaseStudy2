using KaizenCaseStudy2.Models;
using Microsoft.AspNetCore.Mvc;

namespace KaizenCaseStudy2.Controllers;

[ApiController]
[Route("[controller]")]
public class ReceiptController : ControllerBase
{
    [HttpPost]
    public ActionResult<List<string>> ParseReceipt([FromBody] Receipt request)
    {
        var index = 0;
        var currentLocation = request.Items.FirstOrDefault()?.boundingPoly.vertices[0].x;
        var itemList = new List<string>
        {
            ""
        };

        for (var i = 1; i < request.Items.Count; i++)
        {
            if (request.Items[i].boundingPoly.vertices[1].x < currentLocation)
            {
                itemList.Add(request.Items[i].description);
                index++;
            }
            else
            {
                itemList[index] += " " + request.Items[i].description;
            }

            currentLocation = request.Items[i].boundingPoly.vertices[1].x;
        }

        // Return the receipt text as the response
        return itemList;
    }
}