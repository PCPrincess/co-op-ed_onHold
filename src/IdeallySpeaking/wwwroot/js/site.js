/**
 * Created by PCPrincess on 12/16/2016.
 */


// Tabbed Content Box
var tabs = document.querySelectorAll('.tabbed-content-box li a');
var panels = document.querySelectorAll('.tabbed-content-box article');

for (i = 0; i < tabs.length; i++) {
    var tab = tabs[i];
    setTabHandler(tab, i);
}

function setTabHandler(tab, tabPos) {
    tab.onclick = function () {
        for (i = 0; i < tabs.length; i++) {
            if (tabs[i].getAttribute('class')) {
                tabs[i].removeAttribute('class');
            }
        }

        tab.setAttribute('class', 'active');

        for (i = 0; i < panels.length; i++) {
            if (panels[i].getAttribute('class')) {
                panels[i].removeAttribute('class');
            }
        }

        panels[tabPos].setAttribute('class', 'active-panel');
    }
}

// Stacked-Tab Media Box - Not Working Properly, Do From Scratch!


var stackTabs = document.querySelectorAll('.stacked-tab-media li a');
var panes = document.querySelectorAll('stacked-tab-media .tab-pane');

for (i = 0; i < stackTabs.length; i++) {
    var tabChoice = stackTabs[i];
    stackTabHandler(tabChoice, i);
}

function stackTabHandler(tabChoice, position) {
    tabChoice.onclick = function () {
        var tabNum = stackTabs[i].getAttribute('href');        

        for (i = 0; i < panes.length; i++) {
            if (panes[i].getAttribute('id') === tabNum) {
                panes[position].setAttribute('class', 'pane-active');
            }
        }        

    }

}



