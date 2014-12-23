$(function() {
	var name = fileSystem.name;
	var content_div = $("#content");

	var root = $("#folder")
		.clone()
		.removeAttr("id")
		.appendTo("#tree")
		.find(".caption")
		.text(name)
		.end()
		.click(function(event) {
			event.stopPropagation();
			
			var self = $(this);
			var children = self.find(".list-group");
			
			content_div.text("Please select a file");
			if(fileSystem.isLoaded) {
				children.slideToggle();
				return;
			}
			
			self.addClass("loading");
			
			fileSystem.loadChildren().done(function() {
				for(var i = 0; i < fileSystem.children.length; i++) {
				    if(fileSystem.children[i].isFolder) {

				        CurFolder = fileSystem.children[i];
				        function abc(CurFolder) {
				        var a = $("#folder")
							.clone()
							.removeAttr("id")
							.appendTo(children)
							.find(".caption")
							.text(fileSystem.children[i].name)
                            .end();
                            a.click(function (ev) {
                                ev.stopPropagation();
				                var self_1 = $(this);
				                EventForFolder(CurFolder,self_1)
				        });
				        }
				        abc(CurFolder);
				   }

				    else
				    {
				   
				        var a = $("#file")
                            .clone()
                            .removeAttr("id")
                            .appendTo(children)
                            .find(".caption")
                            //later: .data("file").content
                            .text(fileSystem.children[i].name)
                            .end();
				        a.data("file", fileSystem.children[i].content);
				        a.click(function(ev)
				        {
				            ev.stopPropagation();
				            content_div.text($(this).data("file"));
				        })
					}
				}

				self.removeClass("loading");
				var b = self.children(".expander.glyphicon.glyphicon-plus");
				{ b.toggleClass("glyphicon-minus") };
				children.slideDown();
			});
		});
	
	// TODO: add files
});



function EventForFolder(_CurrentFolder, _self) {
    var content_div = $("#content");
    self = _self;
    CurrentFolder = _CurrentFolder;
    var children = self.find(".list-group");

    content_div.text("Please select a file");

    if (CurrentFolder.isLoaded) {
        children.slideToggle();
        return;
    }

    self.addClass("loading");

    CurrentFolder.loadChildren().done(function () {
        for (var i = 0; i < CurrentFolder.children.length; i++) {
            if (CurrentFolder.children[i].isFolder) {

                CurFolder = CurrentFolder.children[i];
                function abc(CurFolder) {
                    var a = $("#folder")
                        .clone()
                        .removeAttr("id")
                        .appendTo(children)
                        .find(".caption")
                        .text(CurrentFolder.children[i].name)
                        .end();
                    a.click(function (ev) {
                        ev.stopPropagation();
                        var self_1 = $(this);
                        EventForFolder(CurFolder, self_1)
                    });
                }
                abc(CurFolder);
            }

            else {
                var a = $("#file")
                    .clone()
                    .removeAttr("id")
                    .appendTo(children)
                    .find(".caption")
                    //later: .data("file").content
                    .text(CurrentFolder.children[i].name)
                    .end();
                a.data("file", fileSystem.children[i].content);
                a.click(function(ev)
                {
                    ev.stopPropagation();
                    content_div.text($(this).data("file")) ;
                })
            }
        }

        self.removeClass("loading");

        var b = self.children(".expander.glyphicon.glyphicon-plus");
        { b.toggleClass("glyphicon-minus") };
        children.slideDown();
    });
}