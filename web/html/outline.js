    /*  The following statement must not be removed from this code:

        This code is copyright 1997 by Scott Isaacs. More information about this
        code can be found at Inside Dynamic HTML: HTTP://www.insideDHTML.com
        You are permitted use this code on non-profit sites as long as it is left unmodified. 

        This code cannot be changed, used on commercial sites, or reproduced in any manner without
        prior consent of Scott Isaacs - scotti@insideDHTML.com 
    */

  function getLevel(el) {
    var cnt = 0
    while (el.className!="outlineMenu") {
      if (el.tagName=="UL")
        cnt++
      el = el.parentElement
    }
    return ((.7 * (cnt-1))+.3)
  }

  function doClickOutline() {
    if ((event.srcElement.tagName=="SPAN") && (event.srcElement.className=="outlineMore")) {
      child = event.srcElement.parentElement.children.tags("UL")[0]
      if (child.style.display=="block") {
        child.style.display = ""
        event.srcElement.innerText="+"
      }
      else {
        if (child.style._level==null)
          child.style._level = getLevel(child)
        child.style.display = "block"
        if (child.style._indent==null) {
          var li = child.all.tags("P")
          for (var i = 0; i<li.length; i++)
            li[i].style.paddingLeft=child.style._level + "em"
        }
        child.style._indent = true
        event.srcElement.innerText="-"
      }
    }
  }

  function getParent(el) {
    if (el.className=="outlineMore") return el
    if ((el.tagName!="P") && (el.tagName!="LI"))
     el = el.parentElement
    return el
  }

  var highlight

  function checkOverOutline() {
    var el =  getParent(event.srcElement)
    if ((el.tagName=="P") || (el.tagName=="LI")) {
      if (el.tagName=="LI") {
        el = el.children.tags("P")
        if (el.length==0) return
        el = el[0]
      }
      el.style.background='navy'
      el.style.color = "white"
      highlight=el
    }
  }


  function checkOutOutline() {
    var el = getParent(event.fromElement) // highlight;
    if (highlight==null) return
    if ((el.tagName=="P") || (el.tagName=="LI")) {
      if (el.tagName=="LI") {
        el = el.children.tags("P")
        if (el.length==0) return
        el = el[0]
      }
      if (null!=event.toElement)
        if (getParent(event.toElement)==el) return
      el.style.background=""
      el.style.color = ""
    }
  }