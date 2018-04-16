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

    <div id="myDashboard"></div>
    <script type="text/javascript">
      (function(d, a, s, h, b, oa, rd) {
        if (!d[b]) {oa = a.createElement(s), oa.async = 1;
        oa.src = h; rd = a.getElementsByTagName(s)[0];
        rd.parentNode.insertBefore(oa, rd);} d[b]=d[b]||{};
        d[b].addDashboard=d[b].addDashboard||function(v) {
        (d[b].list = d[b].list || []).push(v) };
      })(window, document, 'script',
      'https://cdn-a.cumul.io/js/cumulio.min.js', 'Cumulio');

      Cumulio.addDashboard({
        container: '#myDashboard'
        , dashboardId: '<%= ViewData["dashboardId"] %>'
        , key: '<%= ViewData["key"] %>'
        , token: '<%= ViewData["token"] %>'
      });
    </script>

  </body>
</html>