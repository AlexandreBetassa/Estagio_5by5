use universidade;

select a.nome 'Aluno', nota_n1 'Nota 1', nota_n2 'Nota 2', d.nome 'Disciplina' 
from aluno a, matricula m, disciplina d
where a.ra = m.ra and m.sigla = d.sigla and ra = 1;
