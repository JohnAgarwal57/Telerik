module.exports = function (grunt) {
    grunt.initConfig({
        connect: {
            options: {
                port: 9578,
                livereload: 35729,
                hostname: '127.0.0.1'
            },
            livereload: {
                options: {
                    open: true,
                    base: [
                        'dev'
                    ]
                }
            }
        },
        watch: {
            coffee: {
                files: ['Gruntfile.js', 'app/js/**/*.coffee'],
                tasks: ['coffee', 'jshint'],
                options: {
                    livereload: true
                }
            },
            stylus: {
                files: ['app/styles/**/*.styl'],
                tasks: ['stylus'],
                options: {
                    livereload: true
                }
            },
            jade: {
                files: ['app/index.jade'],
                tasks: ['jade'],
                options: {
                    livereload: true
                }
            },
            livereload: {
                options: {
                    livereload: '<%= connect.options.livereload %>'
                },
                files: [
                    'dev/**/*.html',
                    'dev/**/*.css',
                    'dev/**/*.js'
                ]
            }
        },
        jade: {
            compile: {
                options: {
                    pretty: true
                },
                files: {
                    'dev/index.html': 'app/index.jade'
                }
            }
        },
        stylus: {
            compile: {
                options: {
                    compress: false
                },
                files: {
                    'dev/styles/main.css': 'app/styles/app.styl'
                }
            }
        },
        coffee: {
            compile: {
                files: {
                    'dev/scripts/app.js': 'app/js/app.coffee'
                }
            }
        },
        jshint: {
            files: {
                src: ['dev/scripts/*.js']
            }
        },
        copy: {
            main: {
                expand: true,
                cwd: 'app/',
                flatten: true,
                filter: 'isFile',
                src: 'img/*',
                dest: 'dev/images/'
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-jade');
    grunt.loadNpmTasks('grunt-contrib-stylus');
    grunt.loadNpmTasks('grunt-contrib-coffee');
    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-watch');

    grunt.registerTask('serve', [
        'stylus',
        'jade',
        'coffee',
        'jshint',
        'copy',
        'connect',
        'watch']);
};
