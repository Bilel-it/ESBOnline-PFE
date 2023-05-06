        // Select/Deselect checkboxes based on header checkbox
          function SelectAll(headerchk) {


              var gvcheck = document.getElementById('GridView1');
              var i;
              //Condition to check header checkbox selected or not if that is true checked all checkboxes
              if (headerchk.checked ) {
              
                  for (i = 1; i < gvcheck.rows.length; i++) {
                      var inputs = gvcheck.rows[i].getElementsByTagName('input');
                      inputs[0].checked = true;
                    

                  }
              }
              //if condition fails uncheck all checkboxes in gridview
              else {
                  for (i = 1; i < gvcheck.rows.length; i++) {
                      var inputs = gvcheck.rows[i].getElementsByTagName('input');
                      inputs[0].checked = false;
                      inputs[1].checked = false;
                     

                  }
              }
          }

          // Select/Deselect checkboxes based on header checkbox
          function SelectAllP(headerchk) {


              var gvcheck = document.getElementById('GridView1');
              var i;
              //Condition to check header checkbox selected or not if that is true checked all checkboxes
              if (headerchk.checked) {

                  for (i = 1; i < gvcheck.rows.length; i++) {
                      var inputs = gvcheck.rows[i].getElementsByTagName('input');
                      inputs[1].checked = true;
                     

                  }
              }
              //if condition fails uncheck all checkboxes in gridview
              else {
                  for (i = 1; i < gvcheck.rows.length; i++) {
                      var inputs = gvcheck.rows[i].getElementsByTagName('input');
                      inputs[1].checked = false;
                      inputs[0].checked = false;
                  }
              }
          }


                  function CheckBoxCheck(rb) {
                      var gv = document.getElementById("<%=GridView1.ClientID>%");
                      var row = rb.parentNode.parentNode;
                      var rbs = row.getElementsByTagName("input");
                      for (var i = 0; i < rbs.length; i++) {
                          if (rbs[i].type == "checkbox") {
                              if (rbs[i].checked && rbs[i] != rb) {
                                  rbs[i].checked = false;
                                  break;
                              }
                          }
                      }
                  }


         
