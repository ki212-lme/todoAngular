export interface ITodoItem{
  id: number,
  isCompleted: boolean,
  isArchived: boolean,
  description: string,
  dateComplete: Date|null
}
