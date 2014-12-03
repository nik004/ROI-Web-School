// fileSystem API
fileSystem.isLoaded  == false;
fileSystem.isLoading == false;
fileSystem.children  == null;

fileSystem.loadChildren().done(function() {
    fileSystem.isLoaded  == true;
    fileSystem.isLoading == false;
    fileSystem.children  != null;
	
	file.name
	file.content
	
	for(var i = 0; i < fileSystem.children.length; i++) {
		alert(fileSystem.children[i].name);
	}
});

fileSystem.isLoaded  == false;
fileSystem.isLoading == true;
fileSystem.children  == null;