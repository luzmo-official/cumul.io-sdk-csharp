<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html>
<html>
  <head>
    <meta charset="UTF-8">
    <title>Cumul.io embedding example</title>
  </head>
  <body>
    <div style="margin-left: 28px; width: 650px;">
      <h1 style="font-weight: 200;">Cumul.io embedding example</h1>
      <p>This page contains an example of an embedded dashboard of Cumul.io. The dashboard data is securely filtered server-side, so clients can only access data to which your application explicitly grants access (in this case, the "Damflex" product).</p>
    </div>
    <iframe src="<%= ViewData["url"] %>" style="border: 0; width: 1024px; height: 650px;"></iframe>
  </body>
</html>