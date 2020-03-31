import { Component, OnInit } from '@angular/core';
import { UsuariosService } from '../usuarios.service';
import { UsuarioModel } from './usuario.model';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {
  
  usuario: UsuarioModel = new UsuarioModel();
  usuarios: Array<any> = new Array();

  constructor(private usuariosService: UsuariosService) { }

  ngOnInit(): void {
    this.listarUsuarios();
  }

  listarUsuarios(){
    this.usuariosService.listarUsuarios().subscribe( usuarios => {
      this.usuarios = usuarios;
    }, err => {
      console.log('Erro ao listar usuários', err);
    })
  }

  cadastrar(){
    this.usuariosService.cadastrarUsuario(this.usuario).subscribe( usuario =>{ 
        this.usuario = new UsuarioModel();
        this.listarUsuarios();
    }, err=> { 
      console.log('Erro ao cadastrar usuário', err);
    })
  }

  atualizar(){
    this.usuariosService.atualizarUsuario(this.usuario).subscribe( usuario =>{ 
      this.usuario = new UsuarioModel();
      this.listarUsuarios();
    }, err=> { 
      console.log('Erro ao editar usuário', err);
    })
  }

  remover(id : number){
    this.usuariosService.removerUsuario(id).subscribe( usuario =>{ 
      this.usuario = new UsuarioModel();
      this.listarUsuarios();
    }, err=> { 
      console.log('Erro ao excluir usuário', err);
    })
  }

}
