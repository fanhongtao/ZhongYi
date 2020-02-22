$(document).ready(function() {
  initNamedItem("#userinput", "#result", "/ajax/fangjisuggestion", "/ajax/fangji", parseXML)
});

function parseXML(xml) {
  var name = $(xml).find("名称")[0];
  var content = "<h1>" + $(name).attr('hz') + " ( " + $(name).attr('py') + " ) " + $(name).attr('cc') + " </h1>";
  content += getHtmlElement(xml, "介绍");
  content += getZuCheng(xml);
  content += getHtmlElement(xml, "用法");
  content += getHtmlElement(xml, "功用");
  content += getHtmlElement(xml, "主治");
  content += getHtmlElement(xml, "证治机理");
  content += getHtmlElement(xml, "方解");
  content += getHtmlElement(xml, "配伍特点");
  content += getHtmlElement(xml, "辨证要点");
  content += getHtmlElement(xml, "使用注意");
  content += getHtmlElement(xml, "临证加减");
  content += getFuFang(xml);
  content += getJianBie(xml);
  content += getHtmlElement(xml, "医案举例");
  content += getHtmlElement(xml, "方歌");
  $("#result").html(content);
  $("#result a:not([herf])").each(function() {
    $(this).attr('href', window.location.pathname + "?name=" + $(this).text());
  });
}

function getHtmlElement(xml, name) {
  var ele = $(xml).find(name);
  if (ele.length == 0) {
    content = "";
  } else {
    content = "<h2>" + name + "</h2>";
    content += $(ele[0]).html();
  }
  return content;
}

function addSubElement(xml, name) {
  var ele = $(xml).find(name);
  if (ele.length == 0) {
    content = "";
  } else {
    content = "<font class='bold'>" + name + "</font>: ";
    content += $(ele[0]).text() + "<br/>";
  }
  return content;
}

function getZuCheng(xml) {
  var yaoxing = $(xml).find("组成")[0];
  content = "<h2>" + "组成" + "</h2>";
  content += addSubElement(yaoxing, "内容");
  return content;
}

function getYingYong(xml) {
  var yingyong = $(xml).find("应用")[0];
  var content = "<h2>" + "应用" + "</h2>";
  $(yingyong).find("para").each(function() {
    var title = $($(this).find("title")[0]).text();
    content += "<p><font class='bold'>" + title + "</font><br/>";
    content += $($(this).find("text")[0]).html() + "</p>";
  });
  return content;
}

function getJianBie(xml) {
  var jianbie = $(xml).find("鉴别");
  if (jianbie.length == 0) {
    return "";
  }
  
  var content = "<h2>" + "鉴别" + "</h2>";
  jianbie.each(function() {
    var count = 0;
    content += "<font class='bold'>";
    $(this).find("方名").each(function() {
      count++;
      if (count > 1) {
        content += ", ";
      }
      content += getLink($(this).text());
      $(this).remove();
    });
    content += "</font><br/>";
    content += $(this).text();
    content += "<br/>";
  });
  return content;
}

function getFuFang(xml) {
  var fuyao = $(xml).find("附方");
  if (fuyao.length == 0) {
    return "";
  }
  var count = 0;
  var content = "<h2>" + "附方" + "</h2>";
  $(fuyao).each(function() {
    count++;
    if (count > 1) {
      content += ", ";
    }
    content += getLink($(this).text());
  });
  return content;
}

function getLink(name) {
  return "<a href='" + window.location.pathname + "?name=" + name + "'>" + name + "</a>";
}
